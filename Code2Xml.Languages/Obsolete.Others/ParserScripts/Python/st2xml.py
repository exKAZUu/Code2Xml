import cgi
from parser import *
import symbol
import sys
import token
import types

def print_st(tuple):
	print_st2(tuple, 0, 1)

def print_st2(tuple, depth, lastline):
	id = tuple[0]
	if not isinstance(tuple[1], str):
		element_name = symbol.sym_name[id]
		print ('  ' * depth + '<' + element_name + '>')
		for item in tuple[1:]:
			lastline = print_st2(item, depth + 1, lastline)
		print ('  ' * depth + '</' + element_name + '>')
	else:
		element_name = token.tok_name[id]
		print ('  ' * depth + '<' + element_name + ' startline="' + str(tuple[2]) + '">' + cgi.escape(tuple[1]) + '</' + element_name + '>')
	return lastline

ast = suite(sys.stdin.read())
print_st(st2tuple(ast, True))
