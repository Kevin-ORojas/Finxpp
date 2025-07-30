import { CanActivate, ExecutionContext, Injectable } from "@nestjs/common";
import { FireBaseService } from '../../firebase/firebase.service';
import { Observable } from "rxjs";

@Injectable()

export class FirebaseAuthGuard implements CanActivate {
    constructor(private firebaseService: FireBaseService){}
    async canActivate(context: ExecutionContext): boolean | Promise<boolean> | Observable<boolean> {
        const req = context.switchToHttp().getRequest()
    }


}