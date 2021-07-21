import express from 'express';
import * as http from 'http';
import UserController from './api/user-controller';
import cors from 'cors';
import MongooseHelper from './helpers/mongoose-helper';

if (process.env.DEBUG) {
  require('dotenv').config()
}

const app: express.Application = express();
const server: http.Server = http.createServer(app);
const port = process.env.PORT || 3000;

const mongooseHelper = new MongooseHelper();

// here we are adding middleware to parse all incoming requests as JSON 
app.use(express.json());

// here we are adding middleware to allow cross-origin requests
app.use(cors());

new UserController(app)

// this is a simple route to make sure everything is working properly
const runningMessage = `Server running at port ${port}`;
app.get('/', (req: express.Request, res: express.Response) => {
  res.status(200).send(runningMessage)
});
mongooseHelper.connect().then(() => {
  server.listen(port, () => {
    // our only exception to avoiding console.log(), because we
    // always want to know when the server is done starting up
    console.log(runningMessage);
  });
})
