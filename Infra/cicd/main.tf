provider "aws" {
  region     = "us-east-1"
}
terraform {
  backend "s3" {
    bucket  = "brokervault-terraform"
    key    = "cicd"
    region = "us-east-1"
  }
}
data "terraform_remote_state" "infra" {
  backend = "s3"

  config = {
    bucket = "brokervault-terraform"
    key    = "nonprod-infra"
    region = "us-east-1"
  }
}


resource "aws_s3_bucket" "github" {
  bucket = "guildview-cicd"
}

resource "aws_s3_bucket_acl" "gitlab_bucket_acl" {
  bucket = aws_s3_bucket.github.id,
  acl = "private"
}

resource "aws_s3_bucket_server_side_encryption_configuration" "server_side_encryption_config" {
  bucket = aws_s3_bucket.github.id,
  rule {
    apply_server_side_encryption_by_default {
      sse_algorithm     = "AES256"
    }
  }
}

resource "aws_iam_user" "github" {
  name = "githubci"
  path = "/"
}
resource "aws_iam_user_policy_attachment" "github" {
  user = aws_iam_user.github.name
  policy_arn = "arn:aws:iam::aws:policy/AdministratorAccess" #TODO: Should really narrow down the requirements needed to run the app terraform and push to ECR.
}
