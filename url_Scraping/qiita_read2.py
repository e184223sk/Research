# ライブラリのインポート
import http.client
import pandas as pd
import time
# 取得したいページ数
TOTAL_PAGE = 900
TIME = int(TOTAL_PAGE / 100)
PER_PAGE = 1

# ユーザ認証
h = {'Authorization': 'Bearer 2678a4b8053cd35949a8c4554d6451ffd3ab5848'}
connect = http.client.HTTPSConnection("qiita.com")
url = "/api/v2/items?"

# 指定するタグ
tag_name = "Java"

# カウント変数
num = 0
pg = 0
count = 0

# tag別に記事をPAGEだけ繰り返し取得
query = "&query=tag%3A" + tag_name
# 検索で指定した期間内に作成された記事数を取得
connect.request("GET", url + query, headers=h)
# 要求に対する応答
res = connect.getresponse()
# 応答の読み出し
res.read()
# サーバーからの応答
print(res.status, res.reason)
print("指定しているタグ: " + tag_name)
total_count = int(res.headers['Total-Count'])
print("total_count: " + str(total_count))

# データを取得してtxtファイルに900個記事を書き出す
for count in range(TIME):
    count += 1
    for pg in range(100):
        pg += 1
        page = "page=" + str(pg) + "&per_page=" + str(PER_PAGE)
        connect.request("GET", url + page + query, headers=h)
        res = connect.getresponse()
        data = res.read().decode("utf-8")
        df = pd.read_json(data)
        filename = "./qiita/" + tag_name + "/page" + str(count) + "-" + str(pg) + ".txt"
        df.to_csv(filename, columns=[
            'title',
            'body',
        ], header=False, index=False)
        print(str(count) + ":" + str(pg) + "/" + str(100) + " 完了")
結果