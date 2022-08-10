resource "aws_security_group" "wrathlc_db" {
  name        = "wrathlc-db"
  vpc_id      = module.vpc.vpc_id
  description = "Allow Postgres in from API"

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port       = 5432
    to_port         = 5432
    protocol        = "tcp"
    security_groups = [aws_security_group.ingress_api.id, aws_security_group.ingress_idp.id]
  }
}

<<<<<<< HEAD
resource "aws_db_subnet_group" "default" {
  name = "main"
  subnet_ids = [aws_subnet.database1a.id, aws_subnet.database1b.id]
}
=======
>>>>>>> 8dd05d412b310702a66a2897b44fa0927a8ceb39
resource "aws_db_instance" "wrathlc" {
  allocated_storage           = 20
  allow_major_version_upgrade = false
  apply_immediately           = false
  auto_minor_version_upgrade  = true
  backup_retention_period     = 14
  backup_window               = "05:00-06:00"
  db_subnet_group_name        = module.vpc.database_subnet_group
  delete_automated_backups    = true
  engine                      = "postgres"
  engine_version              = "14"
  identifier                  = "wrathlc"
  instance_class              = "db.t3.small"
  maintenance_window          = "Mon:06:01-Mon:10:00"
  password                    = var.app_db_password
  publicly_accessible         = false
  skip_final_snapshot         = true
  storage_encrypted           = true
  storage_type                = "gp2"
  username                    = "postgres"
  vpc_security_group_ids      = [aws_security_group.wrathlc_db.id]
}
