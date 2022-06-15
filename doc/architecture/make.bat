SETLOCAL
SET DOCUMENT=arch-draft.pdf
SET MAIN=architecture
REM SOURCES  = $(wildcard *.tex) $(wildcard */*.tex) $(wildcard bib/*.bib) $(wildcard *.cls)

REM $(DOCUMENT) : $(SOURCES)
REM         make $(MAIN).pdf || rm $(MAIN).pdf
REM         -mv $(MAIN).pdf $(DOCUMENT)

REM $(MAIN).pdf : $(SOURCES)
REM         latexmk -lualatex -C $(MAIN).tex
REM         latexmk -lualatex $(MAIN).tex

echo %DOCUMENT% %MAIN%
latexmk -lualatex -C %MAIN%.tex
IF %ErrorLevel% NEQ 0 GOTO EXIT
latexmk -lualatex %MAIN%.tex

:EXIT
    if %ErrorLevel% equ 0 (move %MAIN%.pdf %DOCUMENT%)
    if %ErrorLevel% equ 0 (echo "Done: Success") else (echo "Done: Failed")

