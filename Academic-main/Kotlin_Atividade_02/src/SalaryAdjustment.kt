fun exeSalaryAdjustment(salary: Double, percentage: Double): Double {
    return salary * (1 + percentage / 100)
}

fun main() {
    print("Salário: ")
    val salary = readLine()?.toDoubleOrNull()

    print("Percentual: ")
    val percentage = readLine()?.toDoubleOrNull()

    if (salary != null && percentage != null) {
        val newSalary = exeSalaryAdjustment(salary, percentage)
        println("Novo salário: R$ %.2f".format(newSalary))
    } else {
        println("Entrada inválida. Certifique-se de digitar números válidos.")
    }
}
