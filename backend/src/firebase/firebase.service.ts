import { Injectable, OnModuleInit } from '@nestjs/common';
import * as admin from 'firebase-admin';

@Injectable()
export class FireBaseService implements OnModuleInit {
  onModuleInit() {
    admin.initializeApp({
      credential: admin.credential.cert({
        projectId: process.env.FIREBASE_PROJECT_ID,
        clientEmail: process.env.FIREBASE_CLIENT_EMAIL,
        privateKey: process.env.FIREBASE_PRIVATE_KEY?.replace(/\\n/g, '\n'),
      }),
    });
  }

  async verifyToken(token: string) {
    try {
      return await admin.auth().verifyIdToken(token);
    } catch {
      throw new Error('Token is Invalid');
    }
  }
}
