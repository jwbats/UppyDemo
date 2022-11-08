<template>
	<VueDashboard :uppy="uppy" :props="optionsDashboard" />
</template>

<script>
	// axios
	import axios from 'axios';

	// uppy css
	import '@uppy/core/dist/style.css';
	import '@uppy/dashboard/dist/style.css';

	// uppy js
	import Uppy, { debugLogger } from '@uppy/core';
	import XHRUpload from '@uppy/xhr-upload';
	import { Dashboard as VueDashboard } from '@uppy/vue';

	export default {
		name: 'UppyLoader',
		components: {
			VueDashboard
		},
		props: {
			dashboardProps : {},
			uppyProps : {},
			xhrUploadProps : {},
			fileMeta : {}
		},
		data: () => ({
			optionsDashboard: {
				theme: 'light',
				note : 'Description of what to upload.',
				width : '100%',
				height : 600,
				showLinkToFileUploadResult : true,
				showProgressDetails : true,
				proudlyDisplayPoweredByUppy : false
			},
			optionsUppy : {
				debug : false,
				restrictions: {
					allowedFileTypes: ['image/jpeg', 'image/png'],
					maxFileSize: 1000000,
					maxNumberOfFiles: 0
				}
			},
			optionsXhrUpload: {
				endpoint : '/api/UploadFile',
				formData : true,
				headers : { 'accept' : 'application/json' },
				limit : 1
			}
		}),
		created() {
			Object.assign(this.optionsDashboard, this.dashboardProps);
			Object.assign(this.optionsUppy, this.uppyProps);
			Object.assign(this.optionsXhrUpload, this.xhrUploadProps);
		},
		mounted() {
		},
		methods: {
		},
		computed: {
			uppy: function() {
				var uppy = new Uppy(this.optionsUppy);

				uppy.use(XHRUpload, this.optionsXhrUpload);

				uppy.on('file-added', (file) => {
					uppy.setFileMeta(file.id, this.fileMeta);

				});

				return uppy;
			}
		},
		beforeDestroy() {
			this.uppy.close({ reason: 'unmount' });
		}
	}
</script>

<style scoped>

</style>