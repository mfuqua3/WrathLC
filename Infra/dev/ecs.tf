resource "aws_cloudwatch_log_group" "wrathlc_api" {
  name = "/ecs/wrathlc-api"
}
resource "aws_acm_certificate" "wrathlc_api" {
  domain_name       = "api.wrathlc.com"
  validation_method = "DNS"
}

output "domain_validations" {
  value = aws_acm_certificate.wrathlc_api.domain_validation_options
}

resource "aws_ecr_repository" "wrathlc_api" {
  name                 = "wrathlc_api"
  image_tag_mutability = "MUTABLE"

  image_scanning_configuration {
    scan_on_push = true
  }
}
resource "aws_ecr_repository" "wrathlc_idp" {
  name                 = "wrathlc_idp"
  image_tag_mutability = "MUTABLE"

  image_scanning_configuration {
    scan_on_push = true
  }
}
resource "aws_lb_target_group" "wrathlc_api" {
  name = "wrathlc-api"
  port = 5000
  protocol = "HTTP"
  target_type = "ip"
  vpc_id = aws_vpc.app_vpc.id
  health_check {
    enabled = true
    path = "/health"
  }
  depends_on = [aws_alb.wrathlc]
}
resource "aws_lb_target_group" "wrathlc_idp" {
  name = "wrathlc-api"
  port = 5100
  protocol = "HTTP"
  target_type = "ip"
  vpc_id = aws_vpc.app_vpc.id
  health_check {
    enabled = true
    path = "/health"
  }
  depends_on = [aws_alb.wrathlc]
}

resource "aws_alb" "wrathlc" {
  name = "wrathlc"
  internal = false
  load_balancer_type = "application"
  subnets = [
    aws_subnet.public.id,
  ]
  security_groups = [
    aws_security_group.http.id,
    aws_security_group.https.id,
    aws_security_group.ssh.id,
    aws_security_group.egress_all.id,
  ]
  depends_on = [aws_internet_gateway.igw]
}

resource "aws_alb_listener" "wrathlc_http" {
  load_balancer_arn = aws_alb.wrathlc.arn
  port = "80"
  protocol = "HTTP"
  default_action {
    type = "redirect"
    redirect {
      port = "443"
      protocol = "HTTPS"
      status_code = "HTTP_301"
    }
  }
}

 resource "aws_alb_listener" "wrathlc_https" {
   load_balancer_arn = aws_alb.wrathlc.arn
   port              = "443"
   protocol          = "HTTPS"
   certificate_arn   = aws_acm_certificate.wrathlc_api.arn

   default_action {
     type             = "forward"
     target_group_arn = aws_lb_target_group.wrathlc_api.arn
   }
 }

output "alb_url" {
  value = "http://${aws_alb.wrathlc.dns_name}"
}

resource "aws_ecs_task_definition" "wrathlc_api" {
    family = "wrathlc-api"
    execution_role_arn = aws_iam_role.wrathlc_task_execution_role.arn
    container_definitions = <<EOF
    [
        {
          "name": "wrathlc-api",
          "image": "${aws_ecr_repository.wrathlc_api.repository_url}:latest",
          "portMappings": [
            {
              "containerPort": ${aws_lb_target_group.wrathlc_idp.port},
              "hostPort": 443
            }
          ],
          "logConfiguration": {
            "logDriver": "awslogs",
            "options": {
              "awslogs-region": "us-east-1",
              "awslogs-group": "/ecs/wrathlc-api",
              "awslogs-stream-prefix": "ecs"
            }
          }
        }
    ]
    EOF
    cpu = 256
    memory = 512
    requires_compatibilities = ["FARGATE"]
    network_mode = "awsvpc"
}
resource "aws_ecs_task_definition" "wrathlc_idp" {
  family = "wrathlc-idp"
  execution_role_arn = aws_iam_role.wrathlc_task_execution_role.arn
  container_definitions = <<EOF
    [
        {
          "name": "wrathlc-idp",
          "image": "${aws_ecr_repository.wrathlc_idp.repository_url}:latest",
          "portMappings": [
            {
              "containerPort": ${aws_lb_target_group.wrathlc_idp.port},
              "hostPort": 443
            }
          ],
          "logConfiguration": {
            "logDriver": "awslogs",
            "options": {
              "awslogs-region": "us-east-1",
              "awslogs-group": "/ecs/wrathlc-idp",
              "awslogs-stream-prefix": "ecs"
            }
          }
        }
    ]
    EOF
  cpu = 256
  memory = 512
  requires_compatibilities = ["FARGATE"]
  network_mode = "awsvpc"
}
resource "aws_ecs_cluster" "wrathlc" {
   name = "wrathlc"
}
resource "aws_ecs_service" "wrathlc_api" {
    name = "wrathlc-api"
    task_definition = aws_ecs_task_definition.wrathlc_api.arn
    cluster = aws_ecs_cluster.wrathlc.id
    launch_type = "FARGATE"
    network_configuration {
      assign_public_ip = false
      security_groups = [
        aws_security_group.egress_all.id,
        aws_security_group.ingress_api.id
      ]
      subnets = [
        aws_subnet.public.id
      ]
    }
    load_balancer {
      target_group_arn = aws_lb_target_group.wrathlc_api.arn
      container_name = aws_ecr_repository.wrathlc_api.name
      container_port = aws_lb_target_group.wrathlc_api.port
    }
    desired_count = 1
}
resource "aws_ecs_service" "wrathlc_idp" {
  name = "wrathlc-idp"
  task_definition = aws_ecs_task_definition.wrathlc_idp.arn
  cluster = aws_ecs_cluster.wrathlc.id
  launch_type = "FARGATE"
  network_configuration {
    assign_public_ip = false
    security_groups = [
      aws_security_group.egress_all.id,
      aws_security_group.ingress_api.id
    ]
    subnets = [
      aws_subnet.public.id
    ]
  }
  load_balancer {
    target_group_arn = aws_lb_target_group.wrathlc_idp.arn
    container_name = aws_ecr_repository.wrathlc_idp.name
    container_port = aws_lb_target_group.wrathlc_idp.port
  }
  desired_count = 1
}