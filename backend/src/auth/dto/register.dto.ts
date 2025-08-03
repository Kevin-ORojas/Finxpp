import { IsString, MinLength } from 'class-validator';
import { isString } from 'util';

export class RegisterDto {
  @IsString()
  @MinLength(1)
  name: string;

  @IsString()
  email: string;

  @IsString()
  @MinLength(6)
  password: string;
}
