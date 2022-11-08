<template>
	<div class="uppy-container">
		<UppyLoader :dashboardProps="uppyLoaderOptions.dashboard" :uppyProps="uppyLoaderOptions.uppy" :xhrUploadProps="uppyLoaderOptions.xhrUpload" :fileMeta="uppyLoaderOptions.fileMeta" />
	</div>

	<div v-show="false">
		<hr/>
		<p>tg1Result: {{tg1Result}}</p>
		<p>tg2Result: {{tg2Result}}</p>
		<p>tp1Result: {{tp1Result}}</p>
		<p>tp2Result: {{tp2Result}}</p>
	</div>
</template>

<script>
	// axios
	import axios from 'axios';

	// uppy loader
	import UppyLoader from './UppyLoader.vue';

	export default {
		name: 'Uppy Demo',
		components: {
			UppyLoader
		},
		data: () => ({
			uppyLoaderOptions: {
				dashboard: {
					theme: 'light',
					note : 'JPG images only, this and that max size.',
					height : 600,
					showLinkToFileUploadResult : true,
					showProgressDetails : true,
					proudlyDisplayPoweredByUppy : false
				},
				uppy: {
					debug : true,
					restrictions: {
						allowedFileTypes: ['image/jpeg', 'image/png'],
						maxFileSize: 200000,
						maxNumberOfFiles: 0
					}
				},
				xhrUpload: {
					endpoint : '/api/upload/UploadFile2',
				},
				fileMeta: {
					idPackage : 1247
				}
			},
			tg1Result : '',
			tg2Result : '',
			tp1Result : '',
			tp2Result : '',
		}),
		mounted() {
			this.TestGets();
			this.TestPosts();
		},
		methods: {
			TestGets() {
				var params1 = {};
				axios.get('/api/upload/TestGet1')
					.then((result) => {
						this.tg1Result = result.data;
					});

				var params2 = { params: { value1 : 123, value2 : 456 } };
				axios.get('/api/upload/TestGet2', params2)
					.then((result) => {
						this.tg2Result = result.data;
					});
			},
			TestPosts() {
				var params1 = {};
				axios.post('/api/upload/TestPost1')
					.then((result) => {
						this.tp1Result = result.data;
					});

				var params2 = { firstName : 'Barry', lastName : 'Black', age : 27 };
				axios.post('/api/upload/TestPost2', params2)
					.then((result) => {
						this.tp2Result = result.data;
					});
			}
		},
		computed: {
		}
	}
</script>

<style scoped>
	.uppy-container {
		border:1px solid gray;
		padding:5px 10px;
		background:lightgray;
	}

	.test {
		color:purple;
	}
</style>