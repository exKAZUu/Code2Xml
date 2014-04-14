# -*- coding: utf-8 -*-

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
	print_int(len(unicode(str)))
	sys.stdout.write(str)

def print_ast(node):
	id = node[0]
	if not isinstance(node[1], types.StringType):
		print_bool(True)					# IsInnerNode
		print_string(symbol.sym_name[id])	# Name
		print_string(str(id))				# RuleId
		for item in node[1:]:
			if isinstance(item, types.TupleType):
				print_bool(True)			# ExistsNextChild
				print_ast(item)
		print_bool(False)					# ExistsNextChild
	else:
		print_bool(False)					# IsInnerNode
		print_string(token.tok_name[id])	# Name
		print_string(str(id))				# RuleId
		print_string(node[1])				# Text

reload(sys)
sys.setdefaultencoding('utf_8')

if sys.platform == "win32":
    import os, msvcrt
    msvcrt.setmode(sys.stdout.fileno(), os.O_BINARY)

ast = suite(sys.stdin.read())
print_string('WithRuleId')
print_ast(ast2tuple(ast))
sys.stdout.flush()
