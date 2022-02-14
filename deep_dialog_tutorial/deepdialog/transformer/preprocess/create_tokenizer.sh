#!/bin/sh
pipenv run spm_train --pad_id=0 --bos_id=1 --eos_id=2 --unk_id=3 --input=data/pro-jpn3.txt --model_prefix=deepdialog/transformer/preprocess/spm_translate --vocab_size=8000
