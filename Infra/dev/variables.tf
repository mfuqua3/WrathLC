variable "app_db_password" {
  type = string
}
variable "cert_arn" {
  type = string
  default = "arn:aws:acm:us-east-1:602199015882:certificate/a97512c4-e64a-49b3-8372-c659a68db5b1"
}