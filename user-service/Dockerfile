FROM node:14

# Create app directory
WORKDIR /app

COPY package*.json ./
COPY tsconfig.json ./
# copy source code to /app/src folder
COPY src /app/src

RUN npm install
RUN npm run build

EXPOSE 3000
CMD [ "node", "build/index.js" ]