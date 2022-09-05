const HtmlWebpackPlugin = require('html-webpack-plugin');
const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    mode: 'development',
    devServer: {
        port: 8083
    },
    module: {
        rules: [
          {
            test: /\.(js|jsx)$/,
            exclude: /node_modules/,
            use: {
              loader: "babel-loader",
              options: {
                presets: ['@babel/preset-env', '@babel/preset-react']
              }
            }
          },
          {
            test: /\.css$/,
            use: [
              MiniCssExtractPlugin.loader,
              "css-loader", "postcss-loader",
              ],
          },
        ]
    },
    plugins : [
        new MiniCssExtractPlugin({
            filename: "./scr/index.css",
            chunkFilename: "./scr/index.css"
          }),
        new ModuleFederationPlugin({
            name: 'container',
            remotes: {
                products: 'products@http://localhost:8081/remoteEntry.js',
                cart: 'cart@http://localhost:8084/remoteEntry.js',
            }
        }),
        new HtmlWebpackPlugin({
            template: './public/index.html',
        }),
    ],

};