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
<<<<<<< HEAD

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 3.42.0"
    }
  }
}
=======
}
>>>>>>> 8dd05d412b310702a66a2897b44fa0927a8ceb39
