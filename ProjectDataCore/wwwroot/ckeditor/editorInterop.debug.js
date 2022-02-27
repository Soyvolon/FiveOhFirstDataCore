﻿window.DebugCKEditorInterop = (() => {
	const editors = {};

	return {
		init(id, dotNetRef) {
			const watchdog = new CKSource.EditorWatchdog();
			window.watchdog = watchdog;
			watchdog.setCreator((element, config) => {
				return CKSource.Editor
					.create(element, config)
					.then(editor => {

						return editor;
					})
			});

			watchdog.setDestructor(editor => {
				return editor.destroy();
			});

			watchdog.on('error', handleError);

			watchdog
				.create(document.querySelector('.ckeditor'), {
					language: 'en',
					link: {
						decorators: {
							openInNewTab: {
								mode: 'manual',
								label: 'Open in a new tab',
								attributes: {
									target: '_blank',
									rel: 'noopener noreferrer'
								}
							}
						}
					},
					simpleUpload: {
						uploadUrl: 'https://localhost:7111/api/image/upload',
					},
					autosave: {
						save(editor) {
							return saveData(editor.getData());
                        }
                    },
					licenseKey: '',
				})
				.catch(handleError);

			function saveData(data) {
				const el = document.createElement('div');
				el.innerHTML = data;
				if (el.innerText.trim() == '')
					data = null;

				dotNetRef.invokeMethodAsync('EditorDataChanged', data);

				return true;
            }

			function handleError(error) {
				console.error('Oops, something went wrong!');
				console.error('Please, report the following error on https://github.com/ckeditor/ckeditor5/issues with the build id and the error stack trace:');
				console.warn('Build id: a2j0vf9bve5a-w58ttbsi94lt');
				console.error(error);
			}
		},
		destory(id) {
			editors[id].destory()
				.then(() => delete editors[id])
				.catch(error => console.log(error));
		}
	};
})();