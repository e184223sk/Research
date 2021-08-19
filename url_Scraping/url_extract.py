import json
import argparse

parser = argparse.ArgumentParser(description = 'URL取得用です')


parser.add_argument('filename')
args = parser.parse_args()


json_open = open(args.filename,'r')
json_load = json.load(json_open)

# 取得したwebページの数をゲット
length = len(json_load['items'])

linkList = []
s = ''
# webページの数だけリンクを取得していく
for i in range(length):
	linkList += [json_load['items'][i]['link']]
	s += json_load['items'][i]['link'] + '\n'
with open('./test' '.txt', mode='w') as f:
		f.write(s)
print(linkList[0])
