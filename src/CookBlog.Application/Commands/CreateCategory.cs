﻿using CookBlog.Application.Abstractions;

namespace CookBlog.Application.Commands;

public sealed record CreateCategory(string FullName) : ICommand;
