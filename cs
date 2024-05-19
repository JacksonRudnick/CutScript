#!/bin/zsh

if [ "$#" -eq 1 ]; then
	#if there is a parameter, reset the cache and put path to file in it
	touch ~/.cscache
	echo "$PWD/$1" > ~/.cscache
elif [ "$#" -eq 0 ]; then
	#no parameter so get path from cache and mv it to working directory
	if [ -s ~/.cscache ]; then
		cutpath=$(sed -n '1p' < ~/.cscache)
		mv "$cutpath" "$PWD/"
		touch ~/.cscache
	else
		echo "~/.cscache is empty"
	fi
else
	echo "Incorrect number of parameters"
fi
