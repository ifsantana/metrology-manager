export class User {
  name!: string;
  email!: string;
  password!: string;

  constructor(email: string, password: string) {
    this.name = "Admin",
    this.email = email;
    this.password = password
  }
}
