DOCUMENT = arch-draft.pdf
MAIN = architecture
SOURCES  = $(wildcard *.tex) $(wildcard */*.tex) $(wildcard bib/*.bib) $(wildcard *.cls)

$(DOCUMENT) : $(SOURCES)
	make $(MAIN).pdf || rm $(MAIN).pdf
	-mv $(MAIN).pdf $(DOCUMENT)

$(MAIN).pdf : $(SOURCES)
	latexmk -lualatex -C $(MAIN).tex
	latexmk -lualatex $(MAIN).tex


clean :
	-rm $(DOCUMENT) $(MAIN).pdf
	make
