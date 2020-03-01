from flask import Flask, request

app = Flask('TP:KTaNE Helper')

@app.route('/video')
def Video():
	return """
	<html>
	<head>
	<title>Twitch Viewer</title>
	</head>
	<body>
	<iframe
		src="https://player.twitch.tv/?channel=derfer99"
		height="1000"
		width="1000"
	>
	</iframe>
	</body>
	</html>

	"""

@app.route('/chat')
def Chat():
	return """
	<html>
	<head>
	<title>Twitch Viewer</title>
	<script>
		function removeElementsByClass(className){
		var elements = document.getElementsByClassName(className);
		while(elements.length > 0){
			elements[0].parentNode.removeChild(elements[0]);
		}
	}
	window.onload = setTimeout(removeElementsByClass("stream-chat-header tw-align-items-center tw-border-b tw-c-background-base tw-flex tw-flex-shrink-0 tw-full-width tw-justify-content-center tw-pd-l-1 tw-pd-r-1"), 10000)
	</script>
	</head>
	<body>
	<iframe frameborder="0"
			scrolling="no"
			id="chat_embed"
			src="https://www.twitch.tv/embed/derfer99/chat"
			height="500"
			width="350">
	</iframe>
	</iframe>
	</body>
	</html>
	"""

app.run(use_reloader=True, debug=True)
