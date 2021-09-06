import http.client
import json
import pandas as pd

h = {'Authorization': 'Bearer 7eee76482c7ac7d67191b7e3652841974d090ad7'}
conn = http.client.HTTPSConnection("qiita.com")
url = "/api/v2/tags/csharp/items?"


<<<<<<< HEAD
# １回につき記事100枚
# それを100回
# = 10000枚が１回の実行で取得できる最大数
for i in range(100):
=======

for i in range(200):
>>>>>>> f8f9b6f2256c711478d26eb163c10718a493e9a6
    i += 1
    # Qiita APIで記事情報を取得
    page = "page=" + str(i)
    conn.request("GET", url + page + "&per_page=100", headers=h)
    res = conn.getresponse()
    print(res.status, res.reason)
    data = res.read()
    # CSVに出力
    df = pd.read_json(data)
    df.to_csv("qiita8.csv", columns=[
        'url' # 記事URL
        ], mode='a', header=False, index=False)