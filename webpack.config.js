const { VueLoaderPlugin } = require('vue-loader');
const path = require('path');

module.exports = (env) => {
	const isRelease = (env === 'RELEASE');
	return {
		mode: isRelease ? 'production' : 'development',
		devtool: isRelease ? 'source-map' : 'cheap-module-source-map',
		entry: {
			'Main' : './wwwroot/js/Main.js',
		},
		output: {
			path: `${__dirname}/wwwroot/dist/`,
			filename: '[name].js'
		},
		resolve: {
			extensions: ['.js', '.vue'],
			modules: ['node_modules'],
			alias: {
				'@': path.resolve('wwwroot')
			}
		},
		externals: {
			vue: 'Vue'
		},
		plugins: [
			new VueLoaderPlugin()
		],
		stats: {
			entrypoints: true,
			depth: true,
			env: true
		},
		module: {
			rules: [
				{
					test: /\.vue$/,
					use: 'vue-loader',
				},
				{
					test: /\.js$/,
					loader: 'babel-loader',
					options: {
						presets: [
							['@babel/preset-env', {}]
						]
					}
				},
				{
					test: /\.css$/,
					use: ['vue-style-loader', 'css-loader']
				}
			]
		}
	};
};