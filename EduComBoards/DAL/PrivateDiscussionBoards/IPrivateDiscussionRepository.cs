﻿using EduComBoards.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL.PrivateDiscussionBoards
{
    interface IPrivateDiscussionRepository: IPrivateDiscussion<PrivateDiscussionBoard>, IDisposable
    {
    }
}