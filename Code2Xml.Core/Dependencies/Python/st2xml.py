# -*- coding: utf-8 -*-

import io
from parser import *
import symbol
import sys
import token
import types

def print_bool(val):
	sys.stdout.write('1' if val else '0')

def print_int(val):
	sys.stdout.write(str(val))
	sys.stdout.write(',')

def print_string(str):
	print_int(len(str))
	sys.stdout.write(str)

def print_st(node):
	id = node[0]
	if not isinstance(node[1], str):
		print_bool(True)					# IsInnerNode
		print_string(symbol.sym_name[id])	# Name
		print_string(str(id))				# RuleId
		for item in node[1:]:
			if isinstance(item, tuple):
				print_bool(True)			# ExistsNextChild
				print_st(item)
		print_bool(False)					# ExistsNextChild
	else:
		print_bool(False)					# IsInnerNode
		print_string(token.tok_name[id])	# Name
		print_string(str(id))				# RuleId
		print_string(node[1])				# Text

sys.stdin = io.open(sys.stdin.fileno(), 'r', encoding='utf_8')
sys.stdout = io.open(sys.stdout.fileno(), 'w', encoding='utf_8', newline='\n')
sys.stderr = io.open(sys.stderr.fileno(), 'w', encoding='utf_8')

ast = suite(sys.stdin.read())
print_string('WithRuleId')
print_st(st2tuple(ast))
sys.stdout.flush()
