from flask import Flask, request

app = Flask('TP:KTaNE Helper')

@app.route('/video/<channel>')
def Video(channel):
	return f"""
	<html>
	<head>
	<title>Twitch Viewer</title>
	</head>
	<body>
	<iframe
		src="https://player.twitch.tv/?channel={channel}"
		height="1000"
		width="1000"
	>
	</iframe>
	</body>
	</html>

	"""

@app.route('/chat/<channel>')
def Chat(channel):
	return f"""
	<html>
	<head>
	<title>Twitch Viewer</title>
	</head>
	<body>
	<iframe frameborder="0"
			scrolling="no"
			id="chat_embed"
			src="https://www.twitch.tv/embed/{channel}/chat"
			height="500"
			width="350" />
	</body>
	</html>
	"""

app.run(use_reloader=True, debug=True)
