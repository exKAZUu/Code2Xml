# -*- coding: utf-8 -*-

from parser import *
import sys

reload(sys)
sys.setdefaultencoding('utf_8')

if sys.platform == "win32":
    import os, msvcrt
    msvcrt.setmode(sys.stdout.fileno(), os.O_BINARY)

ast2tuple(suite(sys.stdin.read()))
