module "vpc" {
  source = "terraform-aws-modules/vpc/aws"

  name = "wrathlc"
  cidr = "10.0.0.0/16"

  azs              = ["us-east-1a", "us-east-1b", "us-east-1c"]
  #private_subnets  = ["10.0.1.0/24", "10.0.2.0/24", "10.0.3.0/24"]
  database_subnets = ["10.0.51.0/24", "10.0.52.0/24", "10.0.53.0/24"]
  public_subnets   = ["10.0.101.0/24", "10.0.102.0/24", "10.0.103.0/24"]
}

#module "vpc-endpoints" {
#  source = "terraform-aws-modules/vpc/aws//modules/vpc-endpoints"
#
#  vpc_id = module.vpc.vpc_id
#  security_group_ids = [aws_security_group.vpc_endpoint.id]
#  #subnet_ids = module.vpc.private_subnets
#
#  endpoints = {
#    s3 = {
#      service = "s3"
#      tags    = { Name = "s3-vpc-endpoint" }
#      service_type = "Gateway"
#      route_table_ids = module.vpc.private_route_table_ids
#      private_dns_enabled = true
#    },
#    ecs = {
#      service             = "ecs"
#      private_dns_enabled = true
#      subnet_ids          = module.vpc.private_subnets
#      tags    = { Name = "ecs-vpc-endpoint" }
#    },
#    logs = {
#      service             = "logs"
#      private_dns_enabled = true
#      subnet_ids          = module.vpc.private_subnets
#      tags    = { Name = "logs-vpc-endpoint" }
#    },
#
#  }
#}

resource "aws_security_group" "vpc_endpoint" {
  name        = "ecs-endpoint"
  vpc_id      = module.vpc.vpc_id
  description = "Allow All in from the private subnets"

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = concat(module.vpc.private_subnets_cidr_blocks, module.vpc.public_subnets_cidr_blocks)
  }
}

resource "aws_security_group" "http" {
  name        = "http"
  description = "HTTP traffic"
  vpc_id      = module.vpc.vpc_id

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "TCP"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_security_group" "https" {
  name        = "https"
  description = "HTTPS traffic"
  vpc_id      = module.vpc.vpc_id

  ingress {
    from_port   = 443
    to_port     = 443
    protocol    = "TCP"
    cidr_blocks = ["0.0.0.0/0"]
  }
}
resource "aws_security_group" "ssh" {
  name        = "ssh"
  description = "SSH traffic"
  vpc_id      = module.vpc.vpc_id

  ingress {
    from_port   = 22
    to_port     = 22
    protocol    = "TCP"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_security_group" "egress_all" {
  name        = "egress-all"
  description = "Allow all outbound traffic"
  vpc_id      = module.vpc.vpc_id

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_security_group" "ingress_api" {
  name        = "ingress-api"
  description = "Allow ingress to API"
  vpc_id      = module.vpc.vpc_id

  ingress {
    from_port   = aws_lb_target_group.wrathlc_api.port
    to_port     = aws_lb_target_group.wrathlc_api.port
    protocol    = "TCP"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_security_group" "ingress_idp" {
  name        = "ingress-idp"
  description = "Allow ingress to IDP"
  vpc_id      = module.vpc.vpc_id

  ingress {
    from_port   = aws_lb_target_group.wrathlc_idp.port
    to_port     = aws_lb_target_group.wrathlc_idp.port
    protocol    = "TCP"
    cidr_blocks = ["0.0.0.0/0"]
  }
}