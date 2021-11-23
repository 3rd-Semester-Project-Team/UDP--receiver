Console Application to listen for UDP broadcasts from the Raspberry Pi and post the data to a Web Api as a HTTP POST request.

Listens to all IP addresses on port 10100

It still requires the URL for the Parking Web Api. Currently it uses an experimental API to send the POST requst to, for debugging purposes.

Tests:
The UDP listener was tests with SocketTest.
The POST request was sent to https://wordcloudprocessorapi.azurewebsites.net/words to test if the request is send and received.
