## run the following in the terminal
## Open a new terminal window and type the following command to send an HTTP POST request with a JSON body to the API:

curl -X POST -H "Content-Type: application/json" -d '{"githubRepo": "my-repo", "key": "my-key"}' http://localhost:5000/randomurls

## This sends an HTTP POST request to the URL http://localhost:5000/randomurls with a JSON body that contains the githubRepo and key properties.

## The API should respond with a JSON object containing the prodUrl, stgUrl, and deploymentUrl properties, which are generated randomly. You should see the response output in the terminal window.

### Example response:

```bash
{"prodUrl":"https://example.com/uf9nynhcex","stgUrl":"https://someurl.net/8odixpmiz5","deploymentUrl":"https://mydomain.com/j9ez7czfqa"}
```

### Note that the URLs generated in the response will be different every time you send the request.

### You can also test the API using Postman or Insomnia by creating a new request with the HTTP method set to POST, the URL set to your API endpoint, and the request body set to a JSON object with the githubRepo and key properties. You should receive a similar JSON response from the API.