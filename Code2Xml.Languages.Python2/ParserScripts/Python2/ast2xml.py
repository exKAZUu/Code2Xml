import cgi
from parser import *
import symbol
import sys
import token
import types

def print_ast(tuple):
	print_ast2(tuple, 0, 1)

def print_ast2(tuple, depth, lastline):
	if not isinstance(tuple, types.TupleType):
		return lastline
	id = tuple[0]
	if not isinstance(tuple[1], types.StringType):
		element_name = symbol.sym_name[id]
		print ('  ' * depth + '<' + element_name + '>')
		for item in tuple[1:]:
			lastline = print_ast2(item, depth + 1, lastline)
		print ('  ' * depth + '</' + element_name + '>')
	else:
		element_name = token.tok_name[id]
		print ('  ' * depth + '<' + element_name + ' startline="' + str(lastline) + '" endline="' + str(tuple[2]) + '">' + cgi.escape(tuple[1]) + '</' + element_name + '>')
		lastline = tuple[2]
		if element_name == 'NEWLINE': lastline += 1
	return lastline

ast = suite(sys.stdin.read())
print_ast(ast2tuple(ast, True))
