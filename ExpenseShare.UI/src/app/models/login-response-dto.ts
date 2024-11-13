export interface LoginResponseDto {
    id: string;
    name: string;
    token: string;
    isAdmin: boolean;
    expiry: number;
}
