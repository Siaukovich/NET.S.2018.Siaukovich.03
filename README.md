# NET.S.2018.Siaukovich.03

* Папка FindNextBiggerNumber содержит решение задачи №5:  
Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа, и null (или -1), если такого числа не существует.  

* Папка FindNthRoot содержит решение задачи №1:  
Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени ( n ∈ N ) из вещественного числа а методом Ньютона с заданной точностью. Разработать модульные тесты (NUnit и (или) MS Unit Test) для тестирования метода. 

* Папка FilterDigits содержит решение задачи №6 2-го дня:  
  Реализовать метод FilterDigit который принимает массив целых чисел и фильтрует его таким образом, чтобы на выходе остались только числа, содержащие заданную цифру (LINQ-запросы не использовать!) Например, для цифры 7, FilterDigit (7,1,2,3,4,5,6,7,68,69,70, 15,17) -> {7, 7, 70, 17}. Разработать модульные тесты (NUnit и MS Unit Test (включая подход DDT)) для тестирования метода.

* Задача FilterDigits решена двумя способами: через строку и через работу с остатком.

* Папка PerformanceTestForFilterDigit содержит тесты задачи FilterDigits для больших массивов. Время, за которое каждый способ решения отработал, записывается в файл PerformanceOutput.log.

* Оба способа показывают примерно одинаковое время работы в NUnit тестах (хотя в LINQPad метод через остатки работает приблизительно в 3 раза быстрее, чем метод через строки).

* В папке GCD находится решение задачи №2 третьего дня:  
Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел. Методы класса помимо вычисления НОД должны предоставлять дополнительную возможность определения значение времени, необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел, а также методы, предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.

* В задании GCD определены методы для поиска НОД без высчитывания времени, с возвратом времени через out-параметр и как часть кортежа. Каждая версия метода есть отдельно для 2, 3 и >3 параметров.
