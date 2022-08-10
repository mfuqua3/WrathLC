resource "aws_s3_bucket" "environments" {
  bucket = "wrathlc-env"
}

resource "aws_s3_bucket_acl" "environments_bucket_acl" {
  bucket = aws_s3_bucket.environments.id
  acl    = "private"
}

resource "aws_s3_bucket_server_side_encryption_configuration" "server_side_encryption_config" {
  bucket = aws_s3_bucket.environments.id
  rule {
    apply_server_side_encryption_by_default {
      sse_algorithm = "AES256"
    }
  }
}

resource "aws_cloudwatch_log_group" "wrathlc_api" {
  name = "/ecs/dev/wrathlc-api"
}
resource "aws_acm_certificate" "wrathlc_wildcard" {
  domain_name       = "*.wrathlc.com"
  validation_method = "DNS"
}
resource "aws_acm_certificate" "wrathlc_api" {
  domain_name       = "api.dev.wrathlc.com"
  validation_method = "DNS"
}
resource "aws_cloudwatch_log_group" "wrathlc_idp" {
  name = "/ecs/dev/wrathlc-idp"
}
resource "aws_acm_certificate" "wrathlc_idp" {
  domain_name       = "idp.dev.wrathlc.com"
  validation_method = "DNS"
}
output "domain_validations" {
  value = aws_acm_certificate.wrathlc_idp.domain_validation_options
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
<<<<<<< HEAD
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
    aws_subnet.public1a.id,
    aws_subnet.public1b.id,
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
=======
>>>>>>> 8dd05d412b310702a66a2897b44fa0927a8ceb39


resource "aws_ecs_task_definition" "wrathlc_api" {
  family                = "wrathlc-api"
  execution_role_arn    = aws_iam_role.wrathlc_task_execution_role.arn
  container_definitions = jsonencode(
    [
      {
        name : aws_ecr_repository.wrathlc_api.name,
        image : "${aws_ecr_repository.wrathlc_api.repository_url}:latest",
        portMappings : [
          {
            containerPort = aws_lb_target_group.wrathlc_api.port,
            hostPort : aws_lb_target_group.wrathlc_api.port
          }
        ],
        environmentFiles : [
          {
            value : "${aws_s3_bucket.environments.arn}/dev.api.aws.env",
            type: "s3"
          }
        ]
        logConfiguration : {
          logDriver : "awslogs",
          options : {
            awslogs-region : "us-east-1",
            awslogs-group : aws_cloudwatch_log_group.wrathlc_api.name,
            awslogs-stream-prefix : "ecs"
          }
        }
      }
    ])
  cpu                      = 256
  memory                   = 512
  requires_compatibilities = ["FARGATE"]
  network_mode             = "awsvpc"
}
resource "aws_ecs_task_definition" "wrathlc_idp" {
  family                = "wrathlc-idp"
  execution_role_arn    = aws_iam_role.wrathlc_task_execution_role.arn
  container_definitions = jsonencode(
    [
      {
        name : aws_ecr_repository.wrathlc_idp.name,
        image : "${aws_ecr_repository.wrathlc_idp.repository_url}:latest",
        portMappings : [
          {
            containerPort : aws_lb_target_group.wrathlc_idp.port,
            hostPort : aws_lb_target_group.wrathlc_idp.port
          }
        ],
        environmentFiles : [
          {
            value : "${aws_s3_bucket.environments.arn}/dev.idp.aws.env",
            type: "s3"
          }
        ],
        logConfiguration : {
          logDriver : "awslogs",
          options : {
            awslogs-region : "us-east-1",
            awslogs-group : aws_cloudwatch_log_group.wrathlc_idp.name,
            awslogs-stream-prefix : "ecs"
          }
        }
      }
    ])
  cpu                      = 256
  memory                   = 512
  requires_compatibilities = ["FARGATE"]
  network_mode             = "awsvpc"
}
resource "aws_ecs_cluster" "wrathlc" {
  name = "wrathlc"
}
resource "aws_ecs_service" "wrathlc_api" {
<<<<<<< HEAD
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
        aws_subnet.public1a.id,
        aws_subnet.public1b.id
      ]
    }
    load_balancer {
      target_group_arn = aws_lb_target_group.wrathlc_api.arn
      container_name = aws_ecr_repository.wrathlc_api.name
      container_port = aws_lb_target_group.wrathlc_api.port
    }
    desired_count = 1
=======
  name            = "wrathlc-api"
  task_definition = aws_ecs_task_definition.wrathlc_api.arn
  cluster         = aws_ecs_cluster.wrathlc.id
  launch_type     = "FARGATE"
  network_configuration {
    assign_public_ip = false
    security_groups  = [
      aws_security_group.egress_all.id,
      aws_security_group.ingress_api.id
    ]
    subnets = module.vpc.public_subnets
  }
  load_balancer {
    target_group_arn = aws_lb_target_group.wrathlc_api.arn
    container_name   = aws_ecr_repository.wrathlc_api.name
    container_port   = aws_lb_target_group.wrathlc_api.port
  }
  desired_count = 1
>>>>>>> 8dd05d412b310702a66a2897b44fa0927a8ceb39
}
resource "aws_ecs_service" "wrathlc_idp" {
  name            = "wrathlc-idp"
  task_definition = aws_ecs_task_definition.wrathlc_idp.arn
  cluster         = aws_ecs_cluster.wrathlc.id
  launch_type     = "FARGATE"
  network_configuration {
    assign_public_ip = false
    security_groups  = [
      aws_security_group.egress_all.id,
<<<<<<< HEAD
      aws_security_group.ingress_api.id
    ]
    subnets = [
      aws_subnet.public1a.id,
      aws_subnet.public1b.id
=======
      aws_security_group.ingress_idp.id
>>>>>>> 8dd05d412b310702a66a2897b44fa0927a8ceb39
    ]
    subnets = module.vpc.public_subnets
  }
  load_balancer {
    target_group_arn = aws_lb_target_group.wrathlc_idp.arn
    container_name   = aws_ecr_repository.wrathlc_idp.name
    container_port   = aws_lb_target_group.wrathlc_idp.port
  }
  desired_count = 1
}
