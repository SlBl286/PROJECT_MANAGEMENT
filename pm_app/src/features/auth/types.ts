export type Login= {
    username : string,
    password : string,
}

export type Register= {
    username : string,
    name: string,
    email : string | undefined,
    phoneNumber : string | undefined,
    avatar : string | undefined,
    password : string,
}
export type User= {
    id : string,
    lastName: string,
    firstName: string,
    token : string,
    username : string,
    refreshToken: string,
}