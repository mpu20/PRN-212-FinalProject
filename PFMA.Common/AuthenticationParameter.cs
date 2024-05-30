namespace PFMA.Common;

public static class AuthenticationParameter
{
    public static string Salt = "PFMA";
    public static int Iterations = 1000;
    public static int HashByteSize = 64;
}