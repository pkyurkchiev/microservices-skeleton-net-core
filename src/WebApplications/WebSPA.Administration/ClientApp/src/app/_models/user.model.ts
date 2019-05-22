export interface IUser {
  id: string,
  firstName: string,
  lastName: string,
  userName: string,
  normalizedUserName: string,
  email: string,
  normalizedEmail: string,
  roleNames: Array<string>
}
