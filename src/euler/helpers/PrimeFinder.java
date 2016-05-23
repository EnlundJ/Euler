package euler.helpers;

public class PrimeFinder {
	public static boolean isPrime(long l) {
		int divisor = 2;
		while (divisor < Math.sqrt(l) + 1) {
			if (l % divisor == 0)
				return false;
			divisor = (divisor == 2) ? 3 : divisor + 2;
		}
		return true;
	}
}
