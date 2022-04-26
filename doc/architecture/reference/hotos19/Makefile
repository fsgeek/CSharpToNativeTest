# This is just for cleaning up

BIBTEX_FILES := $(shell echo *.bib)
SOURCE := $(shell echo *.tex)
PROJECT := notdead

paper: $(SOURCE) $(BIBTEX_FILES)
	pdflatex $(PROJECT)
	bibtex $(PROJECT)
	pdflatex $(PROJECT)
	pdflatex $(PROJECT)
	pdflatex $(PROJECT)

clean:
	rm *.aux *.fdb_latexmk *.fls *.log *.out *.synctex.gz *.bbl *.blg 2> /dev/null || true

all: clean
	rm *.pdf 2> /dev/null || true

rebuild: all paper


