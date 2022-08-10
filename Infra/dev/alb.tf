resource "aws_lb_target_group" "wrathlc_api" {
  name = "wrathlc-api"
  port = 80
  protocol = "HTTP"
  target_type = "ip"
  vpc_id = module.vpc.vpc_id
  health_check {
    enabled = true
    path = "/health"
  }
  depends_on = [aws_alb.wrathlc]
}
resource "aws_lb_target_group" "wrathlc_idp" {
  name = "wrathlc-idp"
  port = 80
  protocol = "HTTP"
  target_type = "ip"
  vpc_id = module.vpc.vpc_id
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
  subnets = module.vpc.public_subnets
  security_groups = [
    aws_security_group.http.id,
    aws_security_group.https.id,
    aws_security_group.ssh.id,
    aws_security_group.egress_all.id,
  ]
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

  default_action {
    type             = "fixed-response"
    fixed_response {
      content_type = "text/plain"
      message_body = "Not Found"
      status_code  = "404"
    }
  }
}

resource "aws_alb_listener_certificate" "root" {
  certificate_arn = var.cert_arn
  listener_arn    = aws_alb_listener.wrathlc_https.arn
}
resource "aws_alb_listener_certificate" "idp" {
  certificate_arn = aws_acm_certificate.wrathlc_idp.arn
  listener_arn    = aws_alb_listener.wrathlc_https.arn
}
resource "aws_alb_listener_certificate" "api" {
  certificate_arn = aws_acm_certificate.wrathlc_api.arn
  listener_arn    = aws_alb_listener.wrathlc_https.arn
}
resource "aws_alb_listener_certificate" "wildcard" {
  certificate_arn = aws_acm_certificate.wrathlc_wildcard.arn
  listener_arn    = aws_alb_listener.wrathlc_https.arn
}

resource "aws_alb_listener_rule" "api" {
  listener_arn = aws_alb_listener.wrathlc_https.arn
  priority     = 100
  action {
    type = "forward"
    target_group_arn = aws_lb_target_group.wrathlc_api.arn
  }
  condition {
    path_pattern {
      values = ["api.dev.wrathlc.com/*"]
    }
  }
}
resource "aws_alb_listener_rule" "idp" {
  listener_arn = aws_alb_listener.wrathlc_https.arn
  priority     = 99
  action {
    type = "forward"
    target_group_arn = aws_lb_target_group.wrathlc_idp.arn
  }
  condition {
    path_pattern {
      values = ["idp.dev.wrathlc.com/*"]
    }
  }
}

output "alb_url" {
  value = "http://${aws_alb.wrathlc.dns_name}"
}