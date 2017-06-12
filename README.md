# MathematicalLinguisticsTask6
## Zadanie 6: Analizator składniowy.

Gramatyki to instrukcje umożliwiające budowanie zdań za pomocą terminali według z góry założonych zasad. Każdy język programowania wymaga formalnej składni w postaci gramatyki. Zastosowanie niepoprawnej składni uniemożliwia kompilację. Analizę składniową można przeprowadzić za pomocą analizatora składniowego, który informuje o błędach.

#### Zaprogramuj analizator składniowy do następującej gramatyki:

S  ::= W ; Z

Z  ::= W ; Z | ε

W ::= P | POW

P  ::= R | (W)

R ::= L | L.L

L ::= C | CL

C ::= 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9

O ::= * | : | + | - | ^

Powyższa gramatyka umożliwia budowanie ciągów składających się liczb rzeczywistych i operacji arytmetycznych (zdań arytmetycznych)
<i>(1.2*3)+5-(23.4+3)^3; 8:13;</i>

#### Zadania:
1. Podana gramatyka nie jest zgodna z założeniami gramatyki klasy LL(1). Należy ją poprawić.

2. Sporządzić diagram składni, który pokazuje sposób działania analizatora z postaci schematu blokowego.

3. Zaprogramować analizator składniowy z użyciem dowolnego języka programowania.

<b>Uwaga:</b>

Oddanie zadania w trakcie bieżących zajęć lub na początku następnych kwalifikuje do otrzymania oceny bardzo dobrej. Każdy następny tydzień spóźnienia skutkuje obniżeniem maksymalnej oceny o 1 stopień, przy czym zaliczenie na ocenę dostateczną później niż po 3 tygodniach od daty ogłoszenia zadania, wymaga przedstawienia wersji programu z wymaganiami na ocenę bardzo dobrą. Na kolejnych zajęciach istnieje możliwość oddania maksymalnie 2 zadań.
