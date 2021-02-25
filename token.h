#pragma once
#include <string>
#include <vector>

using std::string;
using std::vector;

class Token
{
public:

	enum Kind
	{
		WHITESPACE,
		NEWLINE,
		IDENTIFIER,
		LITERAL,
		STRING_LITERAL,
		OPERATOR,
		LINE_COMMENT,
		BLOCK_COMMENT,
		SCOPE,
		CAST,
		TUPLE,
		UNKNOWN
	};
};
