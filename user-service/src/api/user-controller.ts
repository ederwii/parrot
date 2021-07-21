
import express from 'express';
import UserService from '../business/user-service';

const service = new UserService();

export default class UserController {
  constructor(private app: express.Application) {
    this.configureRoutes();
  }

  configureRoutes() {
    this.app
      .route(`/user`)
      .post(async (req, res) => {
        service.Create(req.body).then(() => {
          res.status(201).send();
        }).catch((err) => {
          res.status(400).send(err);
        })
      });

    this.app
      .route(`/user/token`)
      .post(async (req, res) => {
        service.DoLogin(req.body.email).then((token) => {
          res.json({ token });
        }).catch(() => {
          res.sendStatus(401);
        })
      });
  }
}