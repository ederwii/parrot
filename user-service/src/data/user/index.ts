import mongoose, { Schema, Document } from 'mongoose';

export interface UserType extends Document {
  email: string;
  name: string;
}
var options = { timestamps: true }

const schema = {
  email: { type: String, immutable: true, required: true, unique: true },
  name: String
}

const userSchema = new Schema(schema, options);

export default mongoose.model<UserType>("User", userSchema);