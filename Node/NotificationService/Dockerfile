FROM node:10.13.0-jessie

# Create a working directory
WORKDIR /usr/src/app

# Install all dependencies
COPY package*.json ./

RUN npm install

# Bundle App Source
COPY . .

# Expose the port to listen for the request
EXPOSE 3000

# Start the node application
CMD ["npm", "start"]
