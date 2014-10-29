# -*- coding: utf-8 -*-

import io
from parser import *
import sys

sys.stdin = io.open(sys.stdin.fileno(), 'r', encoding='utf_8')
sys.stdout = io.open(sys.stdout.fileno(), 'w', encoding='utf_8', newline='\n')
sys.stderr = io.open(sys.stderr.fileno(), 'w', encoding='utf_8')

st2tuple(suite(sys.stdin.read()))
