const edge = require('edge-js');

const _getForegroundWindowInfos = edge.func({
	assemblyFile: './lib/CrossOver.WindowDetection.dll',
	typeName: 'CrossOver.WindowDetection.WindowDetection',
	methodName: 'GetForegroundWindowInfos'
});

exports.getForegroundWindowInfos = function (callback) {
	_getForegroundWindowInfos(null, (error, result) => {
		if (error) throw error;
		if (!result) return null;

		callback({
			title: result.Title,
			processPath: result.ProcessPath
		});
	});
}