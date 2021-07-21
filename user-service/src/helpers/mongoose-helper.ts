import mongoose from 'mongoose';

export default class MongooseHelper {
  private _state = {
    isConnected: false
  }

  connect() {
    return new Promise((res, rej) => {
      mongoose.set("useCreateIndex", true);

      mongoose.Promise = global.Promise;
      mongoose.connect(`${process.env.DB_URI}`, {
        useNewUrlParser: true
      }).then(() => {
        this._state.isConnected = true;
        console.log('successfully connected to the database');
        res(mongoose)
      }).catch(err => {
        console.log('error connecting to the database');
        rej(err);
      });
    })
  }
}

