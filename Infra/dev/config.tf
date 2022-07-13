# config.tf

provider "aws" {
    region = "us-east-1"
    profile = "tfuser"
}

terraform {
    required_version = ">= 1.0"

  backend "s3" {
    bucket  = "wrathlc-terraform"
    key     = "terraform.tfstate"
    region  = "us-east-1"
    profile = "tfuser"
  }
}