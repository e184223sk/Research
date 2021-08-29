import http.client
import json
import pandas as pd

h = {'Authorization': 'Bearer 7eee76482c7ac7d67191b7e3652841974d090ad7'}
conn = http.client.HTTPSConnection("qiita.com")
url = "/api/v2/tags/csharp/items?"

for i in range(200):
    i += 1
    page = "page=" + str(i)
    conn.request("GET", url + page + "&per_page=100", headers=h)
    res = conn.getresponse()
    print(res.status, res.reason)
    data = res.read()
    df = pd.read_json(data)
    df.to_csv("qiita6.csv", columns=['url'], mode='a', header=False, index=False)