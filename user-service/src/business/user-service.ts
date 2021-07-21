import User, { UserType } from "../data/user";
import BaseService from "./base-service";
import jwt from "jsonwebtoken";

export default class UserService extends BaseService<UserType> {
  constructor() {
    super(User, "email");
  }
  async Create(payload: Partial<UserType>): Promise<string> {
    if (!payload.email) {
      return Promise.reject('Invalid payload');
    }
    const existing = await this.GetFirst({ email: payload.email.toLowerCase() });
    if (!existing) {

      const userId = await super.Create(payload);
      return userId;
    } else {
      return Promise.reject('User already registered');
    }
  }

  /**
   * Attempts to login with username and password
   * @param username 
   * @param password 
   * @returns JWT (bearer token)
   */
  async DoLogin(email: string): Promise<string> {
    return new Promise((res, rej) => {
      this.GetFirst({ email: email.toLowerCase() }).then(async (validUser: UserType | null) => {
        if (!validUser) {
          rej('Invalid credentials');
        } else {
          let info: any = {
            id: validUser._id,
            name: validUser.name,
            email: validUser.email
          };
          if (!process.env.TOKEN_SECRET || !process.env.EXPIRES_IN)
            throw Error('Invalid configuration');
          let token = jwt.sign(info, process.env.TOKEN_SECRET, {
            expiresIn: +process.env.EXPIRES_IN
          });
          res(token)
        }
      })

    })
  }

}