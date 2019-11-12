var webpack = require('webpack');
var path = require('path');
const merge = require('webpack-merge');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const { getAotPlugin } = require('./webpack/webpack.aot.js');

module.exports = function(options, webpackOptions) {
    options = options || {};
    webpackOptions = webpackOptions || {};

    if (options.aot) {
          console.log(`Running build for ${options.client ? 'client' : 'server'} with AoT compilation`);
    }

    const sharedConfig = () => ({
        resolve: { extensions: [ '.ts', '.js'] },
        module: {
            rules: [
                {
                    test: /\.html$/,
                    loader: ['html-loader?minimize=false']
                },
                {
                    test: /\.css$/,
                    loader: ['to-string-loader', 'css-loader']
                },
                {
                    test: /bootstrap\/dist\/js\/umd\//,
                    use: 'imports-loader?jQuery=jquery'
                },
                {
                    test: /\.(png|jpg|jpeg|gif|svg|eot)$/,
                    loader: 'url-loader?limit=25000'
                },
                {
                    test: /\.ttf(\?v=[0-9]\.[0-9]\.[0-9])?$/,
                    loader: 'url-loader?limit=10000&name=./[hash].[ext]'
                },
                {
                    test: /\.(woff|woff2)(\?v=[0-9]\.[0-9]\.[0-9])?$/,
                    loader: 'url-loader',
                    query: {
                        mimetype: 'application/font-woff',
                        limit: 10000
                    }
                }
            ]
        },
        plugins: [
            new webpack.ProvidePlugin({
                $: "jquery",
                jQuery: "jquery",
                "window.jQuery": "jquery",
                "Tether": 'tether'
            })]
    });

    const  sharedDevConfig = merge(sharedConfig(),
        {
            module: {
                rules: [
                    {
                        test: /.ts?$/,
                        loader: [
                            'awesome-typescript-loader?silent=true',
                            'angular2-template-loader', 'angular-router-loader'
                        ], 
                        exclude: ['*.aot.ts']
                    }
                ]
            }, 
            plugins: [
                new CheckerPlugin()
            ]
        });

    const sharedAotConfig = merge(sharedConfig(), {
        module: {
            rules: [
                {
                    test: /.ts?$/,
                    loader: [ '@ngtools/webpack'],
                    include: /ClientApp/
                }
            ]
        }
    });

    const sharedClientConfig = () => ({
        devtool: 'source-map',
        entry: {
            'client': './ClientApp/client.ts'
        },
        output: {
            path: __dirname + '/wwwroot/dist/',
            publicPath: '/dist/',
            filename: 'client.js',
        },
        target: 'web',
        plugins: [
            new webpack.ContextReplacementPlugin(
                /angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/,
                rootOther('./src'),
                {}
            )
        ]
    });

    const sharedServerConfig = () => ({
        devtool: 'inline-source-map',
        resolve: {
            extensions: ['.ts', '.js', '.json'],
            modules: ['ClientApp', 'node_modules']
        },
        output: {
            libraryTarget: 'commonjs',
            path: __dirname + '/ClientApp/dist/',
            publicPath: '/ClientApp/dist/',
            filename: 'server.js'
        },
        target: 'node'
    });

    let devClientConfig = merge(sharedDevConfig, sharedClientConfig());

    let aotClientConfig = merge(sharedAotConfig, sharedClientConfig(),
        {
            plugins: [getAotPlugin('client', !!options.aot) ]
        });

    const devServerConfig = merge(sharedDevConfig,
        sharedServerConfig(),
        {
            entry: {
                'server': './ClientApp/server.ts'
            }
        });

    const aotServerConfig = merge(sharedAotConfig,
        sharedServerConfig(),
        {
            entry: {
                'server': './ClientApp/server.aot.ts'
            }, 
            plugins: [ getAotPlugin('server', !!options.aot) ]
        });

    const prodConfig = () => ({});

    if (webpackOptions.prod) {
        devClientConfig = merge({}, devClientConfig, prodConfig());
        aotClientConfig = merge({}, aotClientConfig, prodConfig());
    }

    const configs = [];
    if (!options.aot) {
        configs.push(devClientConfig, devServerConfig);
    } else if(options.client) {
        configs.push(aotClientConfig);
    } else if (options.server) {
        configs.push(aotServerConfig);
    }

    return configs;
};

function rootOther(__path) {
    return path.join(__dirname, __path);
}