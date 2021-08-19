#!/usr/bin/env python3
# -*- coding: utf-8 -*-

import os
from datetime import datetime
import json
from googleapiclient.discovery import build

GOOGLE_API_KEY = "AIzaSyAZsIvyuudZkjBHPzNC3UI2SdAbvijVQYM"
CUSTOM_SEARCH_ENGINE_ID = "4c27505d020abdf93"
KEYWORD = "C# qiita"

if __name__ == '__main__':

	s = build("customsearch",
	"v1",
	developerKey = GOOGLE_API_KEY)
	r = s.cse().list(q = KEYWORD,
	cx = CUSTOM_SEARCH_ENGINE_ID,
	lr = 'lang_ja',
	num = 10,
	start = 1).execute()
	s = json.dumps(r, ensure_ascii = False, indent = 4)
	now = datetime.today().strftime("%Y%m%d%H%M%S")
	with open('./res_' + now + '.json', mode='w') as f:
		s = s.replace('\xa0','').replace('\xae','').replace('\u2014','')
		f.write(s)